import TeamMemberSprint from './team-member-sprint';

export default class SprintData {
  public name: string = 'Sprint 1';
  public startDate: string | null = null;
  public endDate: string | null = null;
  public teamMemberSprints: TeamMemberSprint[] = [];
}
