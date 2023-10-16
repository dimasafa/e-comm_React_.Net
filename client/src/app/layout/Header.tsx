import { ShoppingCart } from "@mui/icons-material";
import { AppBar, Badge, IconButton, List, ListItem, Toolbar, Typography } from "@mui/material";
import { Box } from "@mui/system";
import { Link, NavLink } from "react-router-dom";
import { useAppSelector } from "../store/configureStore";
import SignedInMenu from "./SignedInMenu";


const rightLinks = [
    { title: 'login', path: '/login' },
    { title: 'register', path: '/register' }
]

const navStyles = {
    color: 'inherit',
    textDecoration: 'none',
    typography: 'h6',
    '&:hover': {
        color: 'grey.300'
    },
    '&.active': {
        color: '#cddc39'
    }
}

export default function Header() {
    const { basket } = useAppSelector(state => state.basket);
    const { user } = useAppSelector(state => state.account);
    const itemCount = basket?.items.reduce((sum, item) => sum + item.quantity, 0);

    return (
        <AppBar position='static' sx={{ mb: 4, backgroundColor: '#26a69a' }}>
            <Toolbar sx={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center', height: '80px' }}>

                <Box display='flex' alignItems='center'>
                    <Typography variant="h6" component={NavLink}
                        to='/'
                        sx={navStyles}
                    >
                        TEST-STORE
                    </Typography>
                </Box>

                <Box display='flex' alignItems='center'>
                    <IconButton component={Link} to='/basket' size='large' edge='start' color='inherit' sx={{ mr: 2 }}>
                        <Badge badgeContent={itemCount} color="primary">
                            <ShoppingCart />
                        </Badge>
                    </IconButton>

                    {user ? (
                        <SignedInMenu />
                    ) : (
                        <List sx={{ display: 'flex' }}>
                            {rightLinks.map(({ title, path }) => (
                                <ListItem
                                    component={NavLink}
                                    to={path}
                                    key={path}
                                    sx={navStyles}
                                >
                                    {title.toUpperCase()}
                                </ListItem>
                            ))}
                        </List>
                    )}
                </Box>
            </Toolbar>
        </AppBar>
    )
}