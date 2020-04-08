import React, { Component } from 'react';
import { Route, Switch } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { AccountRegister } from './components/AccountRegister';
import { Login } from './components/Login';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

    render() {
    return (
        <Layout>
            <Route exact path='/' component={Home} />
            <Route path='/Register' component={AccountRegister} />
            <Route path='/Login' component={Login} />
        </Layout>
    );
  }
}
