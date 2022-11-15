import React from 'react';
import { BrowserRouter as Router, Routes, Route, Link } from "react-router-dom";
import Tickets from './pages/Tickets';
import { routes } from './routes';

const AppRouter = () => {
    return (
        <Router>
            <Routes>
            <Route index element={ <Tickets />} />
            {routes.map(route =>
                <Route exact={route.exact} path={route.path} element={route.component} key={route.path}></Route>
            )}
            <Route path="*" element={ <Tickets />} />
            </Routes>
        </Router>
    );
};

export default AppRouter;