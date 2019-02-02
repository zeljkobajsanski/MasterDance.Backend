const webpack = require('webpack');
const path = require("path");

module.exports = {
    outputDir: path.resolve(__dirname, "../MasterDance.WebUI/wwwroot"),
    configureWebpack: {
         plugins: [
            new webpack.ProvidePlugin({
                $: "jquery",
                jQuery: "jquery"
            })
        ],
    },
     devServer: {
        proxy: {
            '/api': {
                target: 'https://localhost:5001',
                changeOrigin: true
            },
            '/Images': {
                target: 'https://localhost:5001',
                changeOrigin: true
            }
        }
    }

};