<template>
  <div id="app" class="container">
    <h1>Sprint Capacity Planner</h1>
    <Sprint />
  </div>
</template>

<script lang="ts">
import Vue from 'vue';
import Sprint from './components/Sprint.vue';

export default Vue.extend({
  name: 'app',
  components: {
    Sprint,
  },
});
</script>

<style>
</style>
