import React, {useState} from "react";
import authService from "../Services/auth-service";
import {useNavigate} from "react-router-dom";

export const Register = () => {

    let navigate= useNavigate();

    const[userName, setUserName] = useState("")
    const [Password, setPassword] = useState("")
    const [Email, setEmail] = useState("")

    const handleSubmit =(e) =>{
        e.preventDefault();
        authService.register(userName,Email,Password)
                        .then((res)=>{
                          if(res.data.message === "User Email already registerd"){
                            alert(res.data.message)
                          }else{
                            alert(res.data.message);
                            navigate("/login");
                          }
                        })
                            .catch((err)=>{
                              if(err.response){
                                console.log(err,"yy")
                              }
                            })               
    }

  return(
    <div className="container" data-testid="testRegister" id="loginContainer">
      <form onSubmit={handleSubmit}>
        <div className="mb-3">
          <label htmlFor="Email" className="form-label">
            Email address
          </label>
          <input
            data-testid="testEmailInput"
            type="email"
            className="form-control"
            id="Email"
            name="Email"
            value={Email}
            onChange={(e)=> setEmail(e.target.value)}
            aria-describedby="emailHelp"
          />
        </div>
        <div className="mb-3">
          <label htmlFor="userName" className="form-label">
            User Name
          </label>
          <input
            type="text"
            className="form-control"
            value={userName}
            id="userName"
            onChange={(e)=> setUserName(e.target.value)}
            name="uerName"
          />
        </div>
        <div className="mb-3">
          <label htmlFor="Password" className="form-label">
            Password
          </label>
          <input
            type="password"
            name="Password"
            className="form-control"
            onChange={(e)=> setPassword(e.target.value)}
            value = {Password}
            id="Password"
          />
        </div>
        <button type="submit" className="btn btn-primary">
          Submit
        </button>
      </form>
    </div>
  );
};
