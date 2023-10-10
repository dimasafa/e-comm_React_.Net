import { Container, Paper, Typography, Divider, Button } from "@mui/material";
import { Link } from "react-router-dom";

export default function NotFound() {
    return (
        <Container component={Paper} style={{height: 400}}>
            <Typography gutterBottom variant={'h3'}>Ups - wir konnten nicht finden, wonach Sie suchen!</Typography>
            <Divider />
            <Button component={Link} to='/catalog' fullWidth>Zurück zum Shop</Button>
        </Container>
    )
}