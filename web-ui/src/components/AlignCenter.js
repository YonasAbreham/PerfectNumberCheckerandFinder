import { Grid } from '@mui/material'
import React from 'react'

export default function AlignCenter(props) {
  return (
    <Grid
      container
      direction="column"
      alignItems="center"
      backgroundColor="rgb(0 0 0 / 20%)"
      sx={{ minHeight: "100vh", padding: 3 }}
    >
      <Grid item xs={1}>
        {props.children}
      </Grid>
    </Grid>
  );
}
