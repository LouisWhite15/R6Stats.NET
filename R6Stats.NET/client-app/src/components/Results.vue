<template>
  <div class="card-columns" >
    <div v-if="results.foundmatch === false">
      No results found.
    </div>
    <b-card v-for="item in results.players" :key="item">
      <b-card-body>
        <b-card-title>{{item.profile.name}}</b-card-title>
        <b-card-text v-html="`Current MMR: ${item.ranked.mmr}<br>Current Rank: ${item.ranked.rank}`"></b-card-text>
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

function mapToFriendlyRank(rank:number) : string
{
  if (rank === 17)
    return "Platinum III";

  return rank.toString();
}
</script>