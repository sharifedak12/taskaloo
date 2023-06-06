import React from 'react';
import { Typography, Container } from '@mui/material';




const Queue = (props) => {
    
    

    return (
        <>
            <Container sx={{height: "100vh", display: "flex", alignItems: "center" , justifyContent: "center"}}>
                <Typography variant="h1" component="h2" gutterBottom>
                    Queue
                </Typography>
                
                
            </Container>
        </>
    );
};

export default Queue;
