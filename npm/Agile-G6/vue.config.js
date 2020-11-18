const path = require('path')

function resolve(dir) {
  return path.join(__dirname, dir)
}

module.exports = {
  productionSourceMap: false,

  configureWebpack: {
    output: {
      libraryExport: 'default',
    },
  },

  chainWebpack: (config) => {
    config.externals({
      vue: 'Vue',
    })
    config.resolve.alias
      .set('@', resolve('packages'))
      .set('@components', resolve('packages/components'))
  },

  devServer: {
    open: true,
  },

  css: {
    extract: false,
  },
}
