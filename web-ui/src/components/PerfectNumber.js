import React, { useState } from "react";

import {
  TextField,
  Box,
  Card,
  CardContent,
  Typography,
  Paper,
} from "@mui/material";

import {APIUrlCheck} from "../Common/Config";

export default function PerfectNUmber() {
   //https://localhost:44333/ or 5001
  const [data, setData] = useState(0);
  const [results, setResults] = useState(Boolean); 

  const onButtonClick = async (e) => {
    debugger;
    setData(e.target.value);
    const url = APIUrlCheck + Number(e.target.value);
    const response = await fetch(url, { method: "GET" }).then((res) =>
      res.json()
    );
    setResults(response);
  };

  return (
    <Card>
      <CardContent sx={{ textAlign: "center" }}>
        <Typography variant="h6" sx={{ my: 3 }}>
          Check perfect number
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
              label="Number"
              name="number"
              type="number"
              variant="outlined"
              InputProps={{
                inputProps: { min: 1 },
              }}
              onChange={onButtonClick}
            />
          </form>
        </Box>
        <Paper elevation={1} style={{ textAlign: "center" }}>
          {results ? (
            <h4>{data} is perfect number</h4>
          ) : (
            <h4>{data} is not perfect number</h4>
          )}
        </Paper>{" "}
      </CardContent>
    </Card>
  );
}
