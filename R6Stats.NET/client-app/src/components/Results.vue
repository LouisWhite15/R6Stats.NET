<template>
  <div class="card-columns" >
    <div v-if="results.foundmatch === false">
      No results found.
    </div>
    <b-card v-for="item in results.players" :key="item">
      <b-card-body>
        <b-card-title><router-link :to="`playerStats/${item.profile.userId}`">{{item.profile.name}}</router-link></b-card-title>
        <b-card-text v-html="`Current MMR: ${item.ranked.mmr}<br>Current Rank: ${mapToFriendlyRank(item.ranked.rank)}`"></b-card-text>
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

  private mapToFriendlyRank(rank:number) : string {
    switch(rank)
    {
      case 9: return "Silver V";
      case 10: return "Silver IV";
      case 11: return "Silver III";
      case 12: return "Silver II";
      case 13: return "Silver I";
      case 14: return "Gold III";
      case 15: return "Gold II";
      case 16: return "Gold I";
      case 17: return "Platinum III";
      case 18: return "Platinum II";
      case 19: return "Platinum I";
    }

    return rank.toString();
  }
}
</script>