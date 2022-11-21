import React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Tickets from "../../routing/pages/Tickets";
import { routes } from "../../routing/routes";
import AppNavBar from "./AppNavBar";

const AppRouter = () => {
  return (
    <Router>
      <AppNavBar />
      <Routes>
        <Route index element={<Tickets />} />
        {routes.map((route) => (
          <Route
            path={route.path}
            element={<route.component />}
            key={route.path}
          ></Route>
        ))}
        <Route path="*" element={<Tickets />} />
      </Routes>
    </Router>
  );
};

export default AppRouter;
