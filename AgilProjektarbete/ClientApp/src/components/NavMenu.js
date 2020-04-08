import React, { Component } from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import './NavMenu.css';

export class NavMenu extends Component {
  static displayName = NavMenu.name;

    constructor(props) {
    super(props);
    this.NavBarRef = React.createRef();
    this.toggleNavbar = this.toggleNavbar.bind(this);
    this.state = {
        collapsed: true,
        auth: false
        };
    }

  toggleNavbar () {
    this.setState({
      collapsed: !this.state.collapsed
    });
    };

    doesHttpOnlyCookieExist (cookiename) {
        var d = new Date();
        d.setTime(d.getTime() + (1000));
        var expires = "expires=" + d.toUTCString();

        document.cookie = cookiename + "=new_value;path=/;" + expires;
        if (document.cookie.indexOf(cookiename + '=') == -1) {
            return true;
        } else {
            return false;
        }
    }

    render() {         
        let display;
        if (this.state.auth) {
            display = <NavItem >
                <NavLink tag={Link} className="text-dark" to="/Logout">Logout</NavLink>
            </NavItem >;
        } else {
            display = <NavItem >
                <NavLink tag={Link} className="text-dark" to="/Login">Login</NavLink>
            </NavItem >;
        }

        return (
        <header>
          <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" light>
            <Container>
              <NavbarBrand tag={Link} to="/">AgilProjektarbete</NavbarBrand>
              <NavbarToggler onClick={this.toggleNavbar} className="mr-2" />
              <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!this.state.collapsed} navbar>
                <ul className="navbar-nav flex-grow">
                <NavItem>
                <NavLink tag={Link} className="text-dark" to="/">Home</NavLink>
                </NavItem>   
                {display}
                </ul>
              </Collapse>
            </Container>
          </Navbar>
        </header>
    );
  }
}
