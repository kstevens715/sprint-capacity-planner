<template>
  <div id="app">
    <nav class="navbar navbar-expand-lg navbar-light bg-light">
      <a class="navbar-brand" href="#">Sprint Capacity Planner</a>
      <ul class="navbar-nav mr-auto">
        <li class="nav-item">
          <a class="nav-link" href="#">New Sprint</a>
        </li>
      </ul>
    </nav>
    <div class="container">
      <SprintsTable />
     </div>
  </div>
</template>

<script lang="ts">
import Vue from 'vue';
import Sprint from './components/Sprint.vue';
import SprintsTable from './components/SprintsTable.vue';

export default Vue.extend({
  name: 'app',
  components: {
    Sprint,
    SprintsTable,
  },
});
</script>

<style>
</style>
