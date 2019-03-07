<template>
  <div id="app">
    <sprint-controller></sprint-controller>
  </div>
</template>

<script lang="ts">
import Vue from 'vue';
import VueRouter from 'vue-router';
import SprintController from './components/SprintController.vue';
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
  components: {
    SprintController,
  },
});
</script>