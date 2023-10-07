import { ThemeProvider } from "@emotion/react";
import Header from "./Header";
import { Container, CssBaseline, createTheme } from "@mui/material";
import { Outlet } from "react-router-dom";


function App() {
  const paletteType = 'light'; // Define paletteType as a string variable

  const theme = createTheme({
    palette: {
      mode: paletteType,
      background: {
        default: paletteType === 'light' ? '#eaeaea': '#121212'
      }
    }
  });


  return (
    <>
    <ThemeProvider theme={theme}>
      <CssBaseline />
      <Header />
      <Container>
        <Outlet />
      </Container>
    </ThemeProvider>

    </>
  );
}

export default App;
