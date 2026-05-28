export interface TaskModel {
  id: string;
  title: string;
  description?: string | null;
  categoryId?: string | null;
  isCompleted: boolean;
}
