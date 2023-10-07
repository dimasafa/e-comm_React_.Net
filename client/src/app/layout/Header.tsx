import { ShoppingCart } from "@mui/icons-material";
import { AppBar, Badge, IconButton, List, ListItem, Toolbar, Typography } from "@mui/material";
import { NavLink } from "react-router-dom";

const midLinks = [
    {title: 'catalog', path: '/catalog'},
    {title: 'about', path: '/about'},
    {title: 'contact', path: '/contact'},
]

const rightLinks = [
    {title: 'login', path: '/login'},
    {title: 'register', path: '/register'},
]

const navStyles = {
    color: 'inherit', 
    textDecoration: 'none',
    typography: 'h6',
    '&:hover': {
        color: 'grey.500'
    },
    '&.active': {
        color: 'text.secondary'
    }
}

export default function Header() {
    return (
        <AppBar position="static" sx={{mb: 4}}>
            <Toolbar sx={{display: 'flex', justifyContent: 'space-between', alignItems: 'center'}}>
                <Typography variant='h6' component={NavLink} to='/'
                sx={navStyles}
                >
                    Re-Store
                </Typography>
                <List sx={{display: 'flex'}}>
                    {midLinks.map(({title, path}) => (
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



                <List sx={{display: 'flex'}}>

                    <IconButton size='large' edge='start' color='inherit' sx={{mr: 2}}>
                        <Badge badgeContent='5' color="secondary" >
                            <ShoppingCart />
                        </Badge>
                    </IconButton>
                    
                    {rightLinks.map(({title, path}) => (
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
            </Toolbar>
        </AppBar>
    )
}