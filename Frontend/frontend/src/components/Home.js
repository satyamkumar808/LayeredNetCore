import React, { useEffect } from 'react'
import {useNavigate} from "react-router-dom";
import { useSelector, useDispatch } from 'react-redux';
import ApiCall from '../Api/ApiCalls';
import { setProducts } from '../Actions/productsActions';

export const Home = () => {

    const dispatch = useDispatch();
    let navigate = useNavigate();
    const products = useSelector((state) => state.allProducts.products)

    const fetch = async() => {
        const responce = await ApiCall.fetchProducts()
        dispatch(setProducts(responce))
    }

    useEffect(()=> {
        if(!localStorage.getItem("user")){
            navigate("/login");
        }else{
            fetch();
        }
    },[])
    
    console.log("Products: ", products);

    return (
        <div className="container">
            <ul>
                {products.map((product, index)=>{
                    return(
                        <div key={index}>
                            <div className = "row">
                                <div className="col">
                                {product.modelNum}
                                </div>
                                <div className="col">
                                {product.description}
                                </div>
                            </div>
                        </div>
                    )
                })}
            </ul>
        </div>
    )
}
