const { defineConfig } = require('@vue/cli-service')
module.exports = {
  transpileDependencies: true,
  chainWebpack: config => {
    config
      .plugin('define')
      .tap(args => {
        args[0]['__VUE_PROD_HYDRATION_MISMATCH_DETAILS__'] = true;
        return args;
      });
  }
}

