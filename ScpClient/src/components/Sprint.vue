<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col-3">
        <div class="list-group">
          <a href="#" class="list-group-item list-group-item-action" @click="currentSection = SprintSection.General" :class="{ active: (currentSection == SprintSection.General)}">General</a>
          <a href="#" class="list-group-item list-group-item-action" @click="currentSection = SprintSection.TeamMembers" :class="{ active: (currentSection == SprintSection.TeamMembers)}">Team Members</a>
          <a href="#" class="list-group-item list-group-item-action" @click="currentSection = SprintSection.Breakdown" :class="{ active: (currentSection == SprintSection.Breakdown)}">Breakdown</a>
          <a href="#" class="list-group-item list-group-item-action" @click="currentSection = SprintSection.Charts" :class="{ active: (currentSection == SprintSection.Charts)}">Charts</a>
        </div>
      </div>
      <div class="col-9">
        <SprintGeneral v-if="currentSection == SprintSection.General" :sprintData="sprintData" @saveForm="saveForm"></SprintGeneral>
        <SprintTeamMembers v-if="currentSection == SprintSection.TeamMembers" :sprintData="sprintData" @addTeamMemberSprint="addTeamMemberSprint"></SprintTeamMembers>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import axios, { AxiosResponse } from 'axios';
import Vue from 'vue';
import { Component } from 'vue-property-decorator';

import TeamMemberSprint from '../models/team-member-sprint';
import SprintData from '../models/sprint-data';
import SprintGeneral from './SprintGeneral.vue';
import SprintTeamMembers from './SprintTeamMembers.vue';

enum SprintSection {
  General,
  TeamMembers,
  Breakdown,
  Charts,
}

@Component({
  components: {
    SprintGeneral,
    SprintTeamMembers,
  },
})
export default class Sprint extends Vue {
  private currentSection: SprintSection = SprintSection.General;
  private sprintData: SprintData = new SprintData();
  private SprintSection = SprintSection;

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