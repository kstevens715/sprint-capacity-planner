<template>
  <form>
    <div class="form-group">
      <label for="name">Name</label>
      <input v-model="name" id="name" type="text" class="form-control" />
    </div>
    <div class="form-group">
      <label for="startDate">Start Date</label>
      <input v-model="startDate" id="startDate" type="date" class="form-control" />
    </div>
    <div class="form-group">
      <label for="endDate">End Date</label>
      <input v-model="endDate" id="endDate" type="date" class="form-control" />
    </div>
    <button type="button" class="btn btn-primary" @click="saveForm">Save</button>
  </form>
</template>

<script lang="ts">
import axios, { AxiosResponse } from 'axios';
import Vue from 'vue';
import { Component } from 'vue-property-decorator';

@Component
export default class Sprint extends Vue {
  private name: string = 'Sprint 1';
  private startDate: string | null = null;
  private endDate: string | null = null;

  private saveForm(): void {
    const formData = {
      name: (this.name as string),
      startDate: this.startDate,
      endDate: this.endDate,
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