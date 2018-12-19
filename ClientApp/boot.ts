import './css/site.css';
import 'bootstrap';
import Vue from 'vue';
import VueRouter from 'vue-router';
Vue.use(VueRouter);

Vue.config.devtools = true;
Vue.config.productionTip = false;

const routes = [
    { path: '/', component: require('./components/home/home.vue.html').default }
];

new Vue({
    el: '#app-root',
    router: new VueRouter({ mode: 'history', routes: routes }),
    render: h => h(require('./components/app/app.vue.html').default)
});
