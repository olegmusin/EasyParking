/// <binding />
var Path = require("path");

module.exports = {
    entry: {
        site: [
            "./Scripts/layoutPage.ts",
            "./Scripts/workPage.ts"
        ]

    },
    output: {
        filename: "bundle.js",
        path: Path.resolve(__dirname, "wwwroot/js/")
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