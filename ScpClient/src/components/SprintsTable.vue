<template>
  <table class="table table-striped">
    <thead>
      <tr>
        <th>Sprint</th>
        <th>Start Date</th>
        <th>End Date</th>
        <th>Points Completed</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="sprint in sprints" :key="sprint.id">
        <td>{{ sprint.name }}</td>
        <td>{{ sprint.startDate }}</td>
        <td>{{ sprint.endDate }}</td>
        <td>{{ sprint.actualPointsCompleted }}</td>
      </tr>
    </tbody>
  </table>
</template>

<script lang="ts">
import Vue from 'vue';

export default Vue.extend({
  props: {
    sprints: Array,
  },
});
</script>

<style scoped>
</style>
