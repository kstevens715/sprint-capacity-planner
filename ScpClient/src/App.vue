<template>
  <div id="app" class="container">
    <h1>Sprint Capacity Planner</h1>
    <Sprint />
    <SprintsTable />
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
    SprintsTable
  },
});
</script>

<style>
</style>
