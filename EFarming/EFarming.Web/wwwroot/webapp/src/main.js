// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from 'vue'
import Iview from 'iview'
import 'iview/dist/styles/iview.css'    // 使用 CSS
import './theme/index.less';
import App from './App'
import router from './router'


Vue.config.productionTip = false

Vue.use(Iview)

/* eslint-disable no-new */
new Vue({
  el: '#app',
  router,
  components: { App },
  template: '<App/>'
})
