import { useRouter } from 'next/router';
import Link from 'next/link';
import { posts } from '@/pages/data';

export default function PostPage() {
  const { query } = useRouter();
  const { categoryId, postId } = query;

  const categoryPosts = posts[categoryId];
  const post = categoryPosts ? categoryPosts.find((p) => p.id === postId) : null;

  if (!post) {
    return <h1>Post not found</h1>;
  }

  return (
    <div className="flex flex-col px-10 py-8">
      <h1 className="text-3xl font-bold text-green-500">{post.title}</h1>
      <hr className='mb-12 border-2 border-black'/>
      
      <p className='text-lg'>{post.content}</p>
      
      <Link href={`/category/${categoryId}`} className="hover:underline hover:text-green-500 mt-10">Back to Posts</Link>
    </div>
  );
}
