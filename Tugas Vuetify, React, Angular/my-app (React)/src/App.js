import React, {Component} from 'react';
import { BrowserRouter as Router, Routes, Route, Link } from 'react-router-dom';
import logo from './logounri.png';
import './App.css';
import Info from './components/Info';
import User from './components/User';
import Blog from './components/Blog';
import Account from './components/Account';

class App extends Component {
  render () {
    return (
      <Router>
        <div className="App">
          <div>
            <Link to="/">Home</Link> |
            <Link to="/account">Account</Link> |
            <Link to="/blog">Blog</Link>
          </div>
          <img src={logo} className="App-logo" alt="Logo"/>
          <Routes>
            <Route exact path="/" element={<User/>} />
            <Route path="/account" element={<Account/>} />
            <Route path="/blog" element={<Blog/>} />
          </Routes>
        </div>
      </Router>
    );
  }
}

export default App;
