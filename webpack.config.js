const path = require('path');
const MiniCssExtractPlugin = require('mini-css-extract-plugin');

module.exports = {
    entry: './styles/styles.css',
    mode: process.env.NODE_ENV,
    module: {
        rules: [
            {
                test: /\.css$/i,
                use: [MiniCssExtractPlugin.loader, 'css-loader', 'postcss-loader'],
            },
            {
                test: /\.woff2?$/i,
                type: 'asset',
            },
        ],
    },
    plugins: [new MiniCssExtractPlugin()],
    output: {
        filename: '[name].js',
        path: path.resolve(__dirname, 'wwwroot'),
        publicPath: '',
        assetModuleFilename: 'assets/[name][ext]',
    },
};
