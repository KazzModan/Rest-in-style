import React from 'react';
import { useNavigate } from 'react-router-dom';
import { Navbar, Nav } from 'react-bootstrap';
import './NavBar.scss';

const NavBar = () => {
    const navigate = useNavigate();

    return (
        <Navbar className="navchik" variant="dark" expand="lg">
            <Navbar.Brand onClick={() => navigate("/landing")} className="logo">Rest In Style</Navbar.Brand>
            <Navbar.Toggle aria-controls="basic-navbar-nav"/>
            <Navbar.Collapse id="basic-navbar-nav" className='custom-collapse'>
                <Nav className="mr-auto align-content-center horizontal_nav">
                    <Nav.Link onClick={() => navigate("/landing")} className="child">ГОЛОВНА</Nav.Link>
                </Nav>
            </Navbar.Collapse>
        </Navbar>
    );
};

export default NavBar;