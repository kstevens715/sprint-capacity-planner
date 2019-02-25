<template>
  <table>
    <thead>
      <tr>
        <th>Sprint</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="sprint in sprints" :key="sprint.id">
        <td>{{ sprint.name }}</td>
      </tr>
    </tbody>
  </table>
</template>

<script lang="ts">
import axios, { AxiosResponse } from 'axios';
import Vue from 'vue';

export default Vue.extend({
  data: () => {
    return {
      sprints: []
    };
  },
  created(): void {
    axios.get('http://localhost:5000/api/sprints').then((response: AxiosResponse) => {
      this.sprints = response.data;
    });
  },
});
</script>

<style scoped>
</style>
