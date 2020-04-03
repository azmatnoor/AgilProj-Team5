import React, { Component } from 'react';

export class Login extends Component {
    static displayName = Login.name;

    constructor(props) {
        super(props);
        this.handleSubmit = this.handleSubmit.bind(this);
        this.state =
        {
            Email: "",
            Password: "",
            RememberMe: false,
        };
    }

    handleChange = (e) => {
        this.setState({ [e.target.name]: e.target.value })
    }

    async handleSubmit(event) {
        event.preventDefault();
        let result = await fetch("/account/login", {
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
        let { Email, Password, RememberMe } = this.state
        return (
            <div>
                <h2 className="display-4 text-center">Register</h2>
                <p className="text-danger text-center" id="errormessage"></p>
                <div className="row mx-auto text-center container">
                    <div className="container col-md-6">
                        <form onSubmit={this.handleSubmit}>
                            <div className="form-group">
                                <label htmlFor="Email" className="control-label">E-Mail</label>
                                <input required type="email" name="Email" id="Email" value={Email} onChange={this.handleChange} className="form-control" />
                            </div>
                            <div className="form-group">
                                <label htmlFor="Password" className="control-label">Password</label>
                                <input required type="password" name="Password" id="Password" value={Password} onChange={this.handleChange} className="form-control" />
                            </div>
                            <div className="form-group">
                                <label><input id="RememberMe" name="RememberMe" value={RememberMe} onChange={this.handleChange} type="checkbox" /> Remember me?</label>
                            </div>
                            <input type="submit" value="Login" className="btn btn-dark w-50 mb-5" />
                        </form>
                    </div>
                </div>
            </div>
        );
    }
}