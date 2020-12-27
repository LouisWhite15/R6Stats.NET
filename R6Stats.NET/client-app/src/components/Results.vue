<template>
  <div id="results">
    <b-alert :show="results.players === null || results.length === 0" dismissible fade variant="danger">An error has occured. Please try again later.</b-alert>
    <div class="card-columns">
      <b-card v-for="item in results.players" :key="item">
        <b-card-body>
          <b-card-title><b-link :to="{ name: 'PlayerStats', params: { id: item.profile.userId }}">{{item.profile.name}}</b-link></b-card-title>
          <b-card-text>
            Level: {{item.stats.level}}
          </b-card-text>
        </b-card-body>
      </b-card>
    </div>
  </div>
</template>

<script lang="ts">
import { Component, Vue, Prop } from 'vue-property-decorator'

@Component
export default class Results extends Vue {
  @Prop() data:any;

  get results() {
    return this.data;
  }
}
</script>