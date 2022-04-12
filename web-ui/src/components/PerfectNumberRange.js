import React, { useState } from "react";
import {
  TextField,
  Button,
  Box,
  Card,
  CardContent,
  Typography,
  Paper,
} from "@mui/material";
import { APIUrlFind } from "../Common/Config";
export default function PerfectNumberRange() {


  const [start, setStart] = useState(0);
  const [end, setEnd] = useState(0);

  const [res, setResult] = useState([]);

  const onButtonClick1 = async (e) => {
    e.preventDefault();
    debugger;
    setStart(e.target.value);
    setEnd(e.target.value);
    const url = APIUrlFind + Number(start) + "&end=" + Number(end);

    const response = await fetch(url, { method: "GET" }).then((res) =>
      res.json()
    );
    setResult(response);
  };

  return (
    <Card>
      <CardContent sx={{ textAlign: "center" }}>
        <Typography variant="h6" sx={{ my: 3 }}>
          Find list of perfect numbers
        </Typography>
        <Box
          sx={{
            "&	.MuiTextField-root": {
              m: 1,
              width: "90%",
            },
          }}
        >
          <form noValidate autoComplete="off">
            <TextField
              id="outlined-basic"
              label="Stat number"
              name="start"
              type="number"
              variant="outlined"
              InputProps={{
                inputProps: { min: 1 },
              }}
              value={start}
              onChange={(e) => setStart(e.target.value)}
            />

            <TextField
              id="outlined-basic"
              label="End number"
              name="end"
              type="number"
              variant="outlined"
              InputProps={{
                inputProps: { min: 1 },
              }}
              value={end}
              onChange={(e) => setEnd(e.target.value)}
            />
            <Button
              type="submit"
              variant="contained"
              size="large"
              sx={{
                width: "90%",
              }}
              onClick={onButtonClick1}
            >
              Find
            </Button>
          </form>
        </Box>
        <br />
        <Paper elevation={1}>
          {res.length > 0 ? res.map((i) => <label><h4>[{i}] </h4></label>) : null}
        </Paper>{" "}
      </CardContent>{" "}
    </Card>
  );
}
