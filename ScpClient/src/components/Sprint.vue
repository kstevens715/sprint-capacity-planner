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
import Vue from 'vue';

export default Vue.extend({
  name: 'Sprint',
  data: function() {
    return {
      name: 'Sprint 1',
      startDate: null,
      endDate: null,
    } 
  },
  props: {
    msg: String,
  },
  methods: {
    saveForm: function() {
      var formData = {
        name: <string>this.name,
        startDate: this.startDate,
        endDate: this.endDate,
      }
      //TODO: Use Axios instead
      this.$http.post('http://localhost:5000/api/values', formData).then(response => {
        console.log("test");
      }, response => {
        console.log(response);
      })
    }
  },
  created: function() {
    this.$http.get('http://localhost:5000/api/values/1234').then(response => {
      console.log(response.body)
    }, response => {
      // error callback
    });
  }
});
</script>

<style scoped>
</style>
