<template>
  <div class="card-columns" >
    <div v-if="results.totalResults === 0">
      No results found.
    </div>
    <b-card v-for="item in results.playerResults" :key="item.playerId">
      <b-card-body>
        <b-card-title>{{item.playerName}}</b-card-title>
        <b-card-text v-html="`Current MMR: ${item.currentMmr}<br>Current Rank: ${item.currentRank}`"></b-card-text>
      </b-card-body>
    </b-card>
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