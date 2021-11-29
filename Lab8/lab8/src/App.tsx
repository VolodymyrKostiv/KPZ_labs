import React from 'react';
import './App.css'; 
import 'antd/dist/antd.css';
import { RegistrationForm } from './components/RegistrationForm/RegistrationForm';
import { UsersTable } from './components/RegistrationForm/UsersTable';
import { ChangeProduct } from './components/ChangeProduct/ChangeProduct'; 
import {
  BrowserRouter as Router,
  Switch,
  Route
} from 'react-router-dom'

function App() {
  return (
    <>
      <Router>
          <Switch>
            <Route path="/allusers">
              <UsersTable />
            </Route>
            <Route path="/product">
              <ChangeProduct />
            </Route>
            <Route path="/">
              <RegistrationForm />
            </Route>
          </Switch>
      </Router>
    </>
  );
}

export default App;
