var path = require("path");
var webpack = require("webpack");

var cfg = {
    devtool: "source-map",
    entry: "app",
    output: {
        path: path.resolve("public/bundled"),
        filename: "bundle.js"
    },
    module: {
        preLoaders: [
            {
                test: /\.js$/,
                exclude: /node_modules/,
                loader: "source-map-loader"
            }
        ],
        loaders: [
            { test: /\.ts$/, exclude: /node_modules/, loader: 'ts-loader' },
            { test: /\.jsx?$/, exclude: /(node_modules|bower_components)/, loader: 'babel' },
            { test: /\.css$/, loader: 'style-loader!css-loader' },
            { test: /\.eot(\?v=\d+\.\d+\.\d+)?$/, loader: "file" },
            { test: /\.(woff|woff2)$/, loader:"url?prefix=font/&limit=5000" },
            { test: /\.ttf(\?v=\d+\.\d+\.\d+)?$/, loader: "url?limit=10000&mimetype=application/octet-stream" },
            { test: /\.svg(\?v=\d+\.\d+\.\d+)?$/, loader: "url?limit=10000&mimetype=image/svg+xml" },
            { test: require.resolve("jquery"), loader: "imports?jQuery=jquery" }
        ]
    },
    plugins: [ 
        new webpack.ProvidePlugin({ "$": "jquery", "jQuery": "jquery" }) 
    ],
    node: { // this is for pixi.js 
        fs: "empty"
    },
    resolve: {
        extensions: ['', '.ts', '.js'],
        root: [
            path.resolve('.'),
            path.resolve('./src'),
            path.resolve('./build/fsx'),
        ],
        alias: {
            'PIXI': 'pixi.js'
        }
    }
};

module.exports = cfg;
