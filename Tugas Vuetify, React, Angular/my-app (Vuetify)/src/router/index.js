import Vue from 'vue'
import VueRouter from 'vue-router'
import WebHome from '../components/WebHome';
import WebLogin from '../components/WebLogin';

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    component: WebHome
  },
  {
    path: '/login',
    component: WebLogin
  }
]

const router = new VueRouter({
  mode: 'history',
  routes: routes
})

export default router
