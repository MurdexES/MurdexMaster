import { useRouter } from 'next/router';
import Link from 'next/link';
import { posts } from '@/pages/data';

export async function getStaticPaths() {
  const res = await fetch('http://localhost:3001/posts');
  const posts = await res.json();

  const paths = posts.map((post) => ({
    params: {
      categoryId: post.categoryId,
      postId: post.id,
    },
  }));

  return { paths, fallback: false };
}

export async function getStaticProps({ params }) {
  const { postId } = params;

  const res = await fetch(`http://localhost:3001/posts/${postId}`);
  const post = await res.json();

  return {
    props: {
      post,
    },
  };
}

export default function PostPage({ post }) {
  if (!post) {
    return <h1>Post not found</h1>;
  }

  return (
    <div className="flex flex-col px-10 py-8">
      <h1 className="text-3xl font-bold text-green-500">{post.title}</h1>
      <hr className='mb-12 border-2 border-black'/>
      
      <p className='text-lg'>{post.content}</p>
      
      <Link href={`/category/${post.categoryId}`} className="hover:underline hover:text-green-500 mt-10">Back to Posts</Link>
    </div>
  );
}
