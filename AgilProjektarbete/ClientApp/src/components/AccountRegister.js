import React, { Component } from 'react';
import { Redirect } from 'react-router-dom';

export class AccountRegister extends Component {
    static displayName = AccountRegister.name;

    constructor(props) {
        super(props);
        this.handleSubmit = this.handleSubmit.bind(this);
        this.state =
        {
            FirstName: "",
            LastName: "",
            Email: "",
            Address: "",
            ZipCode: "",
            Password: "",
            ConfirmPassword: "",
            Role: ""
        };
    }

    handleChange = (e) => {
        this.setState({ [e.target.name]: e.target.value})
    }

    async handleSubmit(event) {
        event.preventDefault();
        let result = await fetch("/account/register", {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(this.state)
        });
        let data = await result.json();
        console.log(data);

        document.getElementById("errormessage").innerHTML = data.errorMessages;

        if (data.success) {
            this.props.history.push('/')
        }
    }

    render() {
        let { FirstName, LastName, Email, Address, ZipCode, Password, ConfirmPassword } = this.state
        return (
            <div>
                <h2 className="display-4 text-center">Register</h2>
                <p className="text-danger text-center" id="errormessage"></p>
                <div className="row mx-auto text-center container">
                    <div className="container col-md-6">
                        <form onSubmit={this.handleSubmit}>
                            <div className="form-group">
                                <label htmlFor="FirstName" className="control-label">First Name</label>
                                <input required type="text" name="FirstName" id="FirstName" value={FirstName} onChange={this.handleChange} className="form-control" />
                            </div>
                            <div className="form-group">
                                <label htmlFor="LastName" className="control-label">Last Name</label>
                                <input required type="text" name="LastName" id="LastName" value={LastName} onChange={this.handleChange} className="form-control" />
                            </div>
                            <div className="form-group">
                                <label htmlFor="Email" className="control-label">E-mail</label>
                                <input required type="email" name="Email" id="Email" value={Email} onChange={this.handleChange} className="form-control" />
                            </div>
                            <div className="form-group">
                                <label htmlFor="Address" className="control-label">Address</label>
                                <input required type="text" name="Address" id="Address" value={Address} onChange={this.handleChange} className="form-control" />
                            </div>
                            <div className="form-group">
                                <label htmlFor="ZipCode" className="control-label">ZipCode</label>
                                <input required type="text" name="ZipCode" id="ZipCode" value={ZipCode} onChange={this.handleChange} className="form-control" />
                            </div>
                            <div className="form-group">
                                <label htmlFor="Password" className="control-label">Password</label>
                                <input required type="password" name="Password" id="Password" value={Password} onChange={this.handleChange} className="form-control" />
                            </div>
                            <div className="form-group">
                                <label htmlFor="ConfirmPassword" className="control-label">Confirm Password</label>
                                <input required type="password" name="ConfirmPassword" id="ConfirmPassword" value={ConfirmPassword} onChange={this.handleChange} className="form-control" />
                            </div>
                            <div className="form-group">
                                <label htmlFor="Role" className="control-label">Select your role</label>
                                <select id="Role" name="Role" defaultValue="Customer" onLoad={this.handleChange} onChange={this.handleChange} className="form-control">
                                    <option value="Customer">Customer</option>
                                    <option value="RestaurantOwner">Restaurant Owner</option>
                                </select>
                            </div>
                            <input type="submit" value="Register" className="btn btn-dark w-50 mb-5"/>
                        </form>
                    </div>
                </div>
            </div>
        );
    }
}