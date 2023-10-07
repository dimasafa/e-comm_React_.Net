import { ThemeProvider } from "@emotion/react";
import Catalog from "../../features/catalog/Catalog";
import Header from "./Header";
import { Container, CssBaseline, createTheme } from "@mui/material";


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
        <Catalog/>
      </Container>
    </ThemeProvider>

    </>
  );
}

export default App;
