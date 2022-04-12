import "./App.css";
import Appbar from "./components/Appbar";
import PerfectNUmber from "./components/PerfectNumber";
import PerfectNumberRange from "./components/PerfectNumberRange";
import { Grid } from "@mui/material";
import AlignCenter from "./components/AlignCenter";

function App() {
  return (
    <div className="App">
      <Appbar />
      <AlignCenter>
        <Grid container spacing={3} width="100%">
          <Grid item xs={6}>
            <PerfectNUmber />
          </Grid>
          <Grid item xs={6}>
            <PerfectNumberRange />
          </Grid>
        </Grid>
      </AlignCenter>
    </div>
  );
}

export default App;
