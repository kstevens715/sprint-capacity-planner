<template>
  <div>
    <div class="list-group">
      <a href="#" class="list-group-item list-group-item-action active">
        General
      </a>
      <a href="#" class="list-group-item list-group-item-action">Team Members</a>
      <a href="#" class="list-group-item list-group-item-action">Breakdown</a>
      <a href="#" class="list-group-item list-group-item-action">Charts</a>
    </div>
    <SprintGeneral :sprintData="sprintData" @saveForm="saveForm"></SprintGeneral>
    <div v-for="teamMemberSprint in sprintData.teamMemberSprints" :key="teamMemberSprint.id">
      <p>Name: {{ teamMemberSprint.teamMemberSprintName }}</p>
    </div>
    <button type="button" class="btn" @click="addTeamMemberSprint">Add</button>
  </div>
</template>

<script lang="ts">
import axios, { AxiosResponse } from 'axios';
import Vue from 'vue';
import { Component } from 'vue-property-decorator';

import TeamMemberSprint from '../models/team-member-sprint';
import SprintData from '../models/sprint-data';
import SprintGeneral from './SprintGeneral.vue';

@Component({
  components: {
    SprintGeneral,
  },
})
export default class Sprint extends Vue {
  private sprintData: SprintData = new SprintData();

  private addTeamMemberSprint(): void {
    this.sprintData.teamMemberSprints.push(new TeamMemberSprint());
  }

  private saveForm(): void {
    const formData = {
      name: (this.sprintData.name as string),
      startDate: this.sprintData.startDate,
      endDate: this.sprintData.endDate,
      teamMemberSprints: this.sprintData.teamMemberSprints,
    };

    axios.post('http://localhost:5000/api/sprints', formData).then((response: AxiosResponse) => {
      this.$router.push('/');
      this.$emit('sprintCreated', response);
    }).catch((response: AxiosResponse) => {
      console.log(response.status);
    });
  }
}
</script>