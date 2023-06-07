import React, { Fragment, useEffect } from 'react';
import { Routes, Route, useNavigate, useLocation } from 'react-router-dom';

import { AppBarComponent } from '../../components';

const AppContent = ({ routes }) => {
    const navigate = useNavigate();
    const location = useLocation();

    useEffect(() => {
        location.pathname === '/' && navigate('/login');
        location.pathname === '' && navigate('/login');


    }, []);

    return (
        <Fragment>
            {location.pathname !== '/login' &&
            location.pathname !== '/verify' &&
            location.pathname !== '/forgot-password' &&
            location.pathname !== '/set-password' &&
            location.pathname !== undefined &&
            location.pathname !== '/' ? (
                <AppBarComponent />
            ) : null}
            <Routes>
                {routes.map((route) => (
                    <Route key={route.id} path={route.path} element={<route.component />} />
                ))}
            </Routes>
        </Fragment>
    );
};

export default AppContent;
