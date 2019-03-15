<template>
  <div>
    <nav class="navbar navbar-expand-lg navbar-light bg-light">
      <router-link to="/" class="navbar-brand">Sprint Capacity Planner</router-link>
      <ul class="navbar-nav mr-auto">
        <li class="nav-item">
          <router-link to="/sprints/new" class="nav-link">New Sprint</router-link>
        </li>
      </ul>
    </nav>
    <div class="container-fluid">
      <router-view :sprints="sprints" @sprintCreated="addSprint"></router-view>
     </div>
  </div>
</template>

<script lang="ts">
import axios, { AxiosResponse } from 'axios';
import Vue from 'vue';
import { Component } from 'vue-property-decorator';

@Component
export default class SprintController extends Vue {
  private sprints: any = [];

  private addSprint(sprint: any) {
    console.log(sprint);
    this.sprints.push(sprint.data);
  }

  private created(): void {
    axios.get('http://localhost:5000/api/sprints').then((response: AxiosResponse) => {
      this.sprints = response.data;
    });
  }
}
</script>