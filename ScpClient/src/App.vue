<template>
  <div id="app">
    <nav class="navbar navbar-expand-lg navbar-light bg-light">
      <router-link to="/" class="navbar-brand">Sprint Capacity Planner</router-link>
      <ul class="navbar-nav mr-auto">
        <li class="nav-item">
          <router-link to="/sprints/new" class="nav-link">New Sprint</router-link>
        </li>
      </ul>
    </nav>
    <div class="container">
      <router-view></router-view>
     </div>
  </div>
</template>

<script lang="ts">
import Vue from 'vue';
import VueRouter from 'vue-router';
import Sprint from './components/Sprint.vue';
import SprintsTable from './components/SprintsTable.vue';

const routes = [
  { path: '/', component: SprintsTable },
  { path: '/sprints/new', component: Sprint },
];

const router = new VueRouter({
  routes,
});

Vue.use(VueRouter);

export default Vue.extend({
  name: 'app',
  router,
});
</script>

<style>
</style>
