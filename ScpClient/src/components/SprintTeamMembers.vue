<template>
  <div>
    <div v-for="teamMemberSprint in sprintData.teamMemberSprints" :key="teamMemberSprint.id">
      <p>Name: {{ teamMemberSprint.teamMemberSprintName }}</p>
    </div>
    <button type="button" class="btn" @click="$emit('addTeamMemberSprint')">Add</button>
  </div>
</template>

<script lang="ts">
import Vue from 'vue';
import Component from 'vue-class-component';
import SprintData from '../models/sprint-data';

@Component({
  props: {
    sprintData: SprintData,
  },
})
export default class SprintTeamMember extends Vue {
}
</script>