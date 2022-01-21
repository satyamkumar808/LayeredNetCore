import React, { useEffect, useState } from 'react'
import { useSelector } from 'react-redux'
import { useNavigate } from 'react-router'
import ApiCalls from '../Api/ApiCalls'
import Product from './Product'

export const Cart = () => {

    const initailValue = []

    const [totalArray, setTotalArray] = useState([])
    const [orderItems, setOredrItems] = useState([])
    const [estDel, setEstDel]=useState(0)
    const [address, setAddress]=useState("")
    const [sModle , setSModle] = useState(0)
    const [cartItems, setCartItems] = useState(initailValue)
    const[total, setTotal] = useState(0)
    const navigate = useNavigate()
    const products = useSelector((state)=> state.allProducts.products)

    const handleTime = () =>{
        cartItems.forEach(product => {
            if(parseInt( product.deliveryTime) > estDel){
                setEstDel(product.deliveryTime)
            }
        });
        console.log(estDel,"handel time")
    }

    const callBack =(productTotal, model,pId, quantity)=>{
        const newArray = []

        let totalVal = 0
        const orderItem = orderItems.find(o => JSON.stringify(o.productId) === JSON.stringify(pId));
        const proTotal = totalArray.find(t=> t.model === model)
        if(!proTotal){
            newArray.push(...totalArray)
            newArray.push({
                "model":model,
                "total":productTotal
            })
            setTotalArray(newArray)
            totalArray.forEach((ele)=>{
                totalVal = ele.total+totalVal;
            })
            setTotal(totalVal)

            console.log(totalArray,"callback if")
        }else{
            proTotal.model = model;
            proTotal.total = productTotal
            totalArray.forEach((ele)=>{
                totalVal = ele.total+totalVal;
            })
            setTotal(totalVal)    
            console.log(totalArray,"callback else")
            
            orderItem.productId = pId
            orderItem.amount = parseInt(quantity)

            console.log(orderItems,"orderItem else callback")  
        }

    }

    const handleChange =(e) =>{
        setSModle(e.target.value);
    }


    const handleSearch = (e) => {
        e.preventDefault()
        const newArray = []
        const orderArray = []
        
        const product = products.find(p => parseInt(p.modelNum) === parseInt(sModle))
        const existPro = cartItems.find(p => parseInt(p.modelNum) === parseInt(sModle))
        if(!existPro){
            console.log(product,"com")
            newArray.push(...cartItems)
            newArray.push(product)
            setCartItems(newArray)
            const orderItem = {
                "productId":product.productId,
                "amount":1
            }
            orderArray.push(...orderItems)
            orderArray.push(orderItem)
            setOredrItems(orderArray)
        }else{
            alert("Item already in cart");
        }
    }

    const handelPlaceOrder = async() => {
        const order = {
            "Address":address,
            "Total":total,
            "EstDelivery":estDel,
            "CartItems":orderItems
        }

        if(total && estDel && address && orderItems){

            var responce = await ApiCalls.createOrders(order)
            if(responce === "Successfully order placed"){
                console.log(responce,"iiii")
            }

            setTotal(0);
            setEstDel(0);
            setSModle(0)
            setOredrItems([]);
            setCartItems([]);
            setTotalArray([]);
            setAddress("");

        }else{
            alert(JSON.stringify(order))
        }
    }

    useEffect(()=>{
        if(!localStorage.getItem("user")){
            navigate("/login")
        }
        handleTime();
    },[cartItems])

    return (
        <div className= "container" id="cart">
            <div className="row" id="content">
                <div className="col" id="cart-items">
                    <form onSubmit={handleSearch} className="row form-group" id="searchContainer">
                        <input className="col form-control" type="text" id="search" placeholder= "Enter Modle No." value={sModle} onChange={handleChange}/>
                        <button className="btn btn-primary col form-control" id="searchButton" type="submit" >Search</button>
                    </form>
                        {cartItems.map((product,index)=>{
                            return (
                                <Product key={index} callBack={callBack} product={product}/>
                            )
                        })}
                </div>
                <div className="col">
                   <div className="row">
                       <div className="col">
                           Address : 
                            <textarea className="form-group" value={address} onChange={(e)=>setAddress(e.target.value)}></textarea>
                       </div>
                   </div>
                   <div className="row">
                       <div className="col">
                            <h3>{estDel}</h3>
                            <h5>Days to arrive</h5>
                       </div>
                   </div> 
                </div>
            </div>
            <div className="row" id="total">
                <div className="col">
                    <i><b>Total: </b></i>{total}
                </div>
                <div className="col">
                    <button type="submit" id="orderbtn" onClick={handelPlaceOrder} className="btn btn-primary">Place Order</button>
                </div>
            </div>
        </div>
    )
}
