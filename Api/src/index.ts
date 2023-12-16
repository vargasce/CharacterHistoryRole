'use strict'
import * as dotevnv from "dotenv"
const app = require("./app");
dotevnv.config();

if (!process.env.PORT || !process.env.HOST) {
    console.log(`No port value specified...`)
}

const PORT = parseInt(process.env.PORT as string, 10);
const HOST = process.env.HOTS as string;

const server = app.listen(PORT, () => {
  console.log(`[*]SERVER ${HOST}:${PORT}`);
});
