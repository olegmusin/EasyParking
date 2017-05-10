/// <binding />
var Path = require("path");

module.exports = {
    entry: {
        site: [
            "./scripts/app.ts"
        ]

    },
    output: {
        filename: "bundle.js",
        path: Path.resolve(__dirname, "wwwroot/dist/")
    },
    module: {
        rules: [
            {
                test: /\.tsx?$/,
                loader: "ts-loader",
                exclude: /node_modules/
            }
        ]
    },
    resolve: {
        extensions: [".tsx", ".ts", ".js"]
    }
};