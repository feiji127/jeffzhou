import Vue from 'vue'
import Router from 'vue-router'
import Index from '@/components/Index'
import Login from '@/components/LoginForm'
import SysManage from '@/components/SysManage'

Vue.use(Router)


export default new Router({
  routes: [
    {
      path: '/',
      name: 'Index',
      component: Index
    },
    {
      path: '/Login',
      name: 'Login',
      component: Login
    },
    {
      path: '/SysManage',
      name: 'SysManage',
      component: SysManage
    }
  ]
})

