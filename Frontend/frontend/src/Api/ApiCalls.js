import authHeader from '../Services/auth-header';
import {BaseUrl} from './BaseUrl';
import axios from 'axios';


const header = authHeader();
const config = {
    headers: header
};

class ApiCall {

    fetchProducts = async() => {
        const response = await axios.get(BaseUrl+"Products/allProducts", config)
        .catch((err)=> console.log(err))
        if(response){
            return response.data;
        }
    }

    createOrders = async (order) => {
        const response = await axios.post(BaseUrl+"Order/createOrders", order, config)
                                        .catch((err)=> console.log(err))
        if(response){
            return response.data;
        }
    }
}

export default new ApiCall();