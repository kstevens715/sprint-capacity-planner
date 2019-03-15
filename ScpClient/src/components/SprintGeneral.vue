<template>
  <form>
    <div class="form-group">
      <label for="name">Name</label>
      <input v-model="sprintData.name" id="name" type="text" class="form-control" />
    </div>
    <div class="form-group">
      <label for="startDate">Start Date</label>
      <input v-model="sprintData.startDate" id="startDate" type="date" class="form-control" />
    </div>
    <div class="form-group">
      <label for="endDate">End Date</label>
      <input v-model="sprintData.endDate" id="endDate" type="date" class="form-control" />
    </div>
    <button type="button" class="btn btn-primary" @click="saveForm">Save</button>
  </form>
</template>

<script lang="ts">

import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import SprintData from '../models/sprint-data';

@Component({
  props: {
    sprintData: SprintData,
  },
})
export default class SprintGeneral extends Vue {
  private saveForm(): void {
    this.$emit('saveForm');
  }
}
</script>